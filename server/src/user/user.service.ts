import * as bcrypt from "bcrypt";
import * as jwt from "jsonwebtoken";
import { Injectable } from "@nestjs/common";
import { CreateUserDto } from "./dto/create-user.dto";
import { LoginUserDto } from "./dto/login-user.dto";
import { PrismaService } from "src/database/prisma.service";
import { User } from "./entities/user.entity";
import { Token } from "./entities/token.entity";

@Injectable()
export class UserService {
	constructor(private readonly prisma: PrismaService) {}

	async findUser(email: string): Promise<User | void> {
		const user = await this.prisma.user.findUnique({
			where: { email: email },
		});

		if (user) return user;
	}

	async register(Dto: CreateUserDto): Promise<Token | string> {
		const existUser = await this.findUser(Dto.email);

		if (existUser) return "Já existe um usuário registrado nesse email";

		const user = await this.prisma.user.create({ data: Dto });

		return await this.code(user.email);
	}

	async login(Dto: LoginUserDto): Promise<Token | string> {
		const user = await this.findUser(Dto.email);

		if (!user) return "Usuário não encontrado";

		if (bcrypt.compare(user.password, Dto.password)) return await this.code(user.email);

		return "Senha incorreta";
	}

	async code(email: string):Promise<Token> {
		const secretKey = process.env.SECRET_KEY;		
		const token = jwt.sign(email, secretKey)
		return new Token(token);
	}

	async decode(token: string){
		const secretKey = process.env.SECRET_KEY;
      	const email = jwt.verify(token, secretKey);
		const user = await this.findUser(email as string);

		if (!user) return "Usuário não encontrado";
		return user;
	}

	async remove(email: string): Promise<User | string> {
		const user = await this.findUser(email);
		console.log(user);
		
		if (!user) return "Usuário não encontrado";

		await this.prisma.user.delete({ where: { email } });
		return user;
	}
}