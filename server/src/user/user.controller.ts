import * as bcrypt from "bcrypt";
import {
	Controller,
	Post,
	Body,
	Param,
	Delete,
	Res,
	HttpStatus,
} from "@nestjs/common";
import { FastifyReply } from "fastify";
import { UserService } from "./user.service";
import { CreateUserDto } from "./dto/create-user.dto";
import { LoginUserDto } from "./dto/login-user.dto";

@Controller("user")
export class UserController {
	constructor(private readonly userService: UserService) {}

	@Post("register")
	async register(
		@Body() createUserDto: CreateUserDto,
		@Res() res: FastifyReply,
	) {
		createUserDto.password = bcrypt.hashSync(createUserDto.password, 10);
		const result = await this.userService.register(createUserDto);

		if (typeof result == "string")
			return res.status(HttpStatus.BAD_REQUEST).send({ msg: result });

		return res.status(HttpStatus.CREATED).send(result);
	}

	@Post("login")
	async login(@Body() LoginUserDto: LoginUserDto, @Res() res: FastifyReply) {
		const result = await this.userService.login(LoginUserDto);

		if (typeof result == "string")
			return res.status(HttpStatus.BAD_REQUEST).send({ msg: result });

		return res.status(HttpStatus.OK).send(result);
	}

	@Delete(":email")
	async remove(@Param("email") email: string, @Res() res: FastifyReply) {
		const result = await this.userService.remove(email);

		if (typeof result == "string")
			return res.status(HttpStatus.BAD_REQUEST).send({ msg: result });

		return res.status(HttpStatus.OK).send(result);
	}
}
