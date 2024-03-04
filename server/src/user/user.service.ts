import { Injectable } from "@nestjs/common";
import { CreateUserDto } from "./dto/create-user.dto";
import { LoginUserDto } from "./dto/login-user.dto";
import { PrismaService } from "src/database/prisma.service";
import { User } from "./entities/user.entity";

@Injectable()
export class UserService {
	constructor(private readonly prisma: PrismaService) {}

	async findUser (email: string): Promise<User | string> {
		const user = await this.prisma.user.findUnique({
			where: { email: email },
		});

		if (user) return user
	}

	async register(Dto: CreateUserDto): Promise<User | string> {
		const existUser = await this.findUser(Dto.email);

		if (existUser) return "Já existe um usuário registrado nesse email";

		const user = await this.prisma.user.create({ data: Dto });

		return user;
	}

	async login(Dto: LoginUserDto) {
		const user = await this.findUser(Dto.email);
		if (!user) return "Usuário não encontrado";
    
		if (user.password == Dto.password) return user;

		return "Senha incorreta";
	}

	async remove(email: string) {
		const user = await this.findUser(email);
		if (!user) return "Usuário não encontrado";

    	await this.prisma.user.delete({where: {email}});
    	return "Usuário deletado"
	}
}