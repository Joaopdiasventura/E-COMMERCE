import { Controller, Get, HttpStatus, Param, Res } from "@nestjs/common";
import { FastifyReply } from "fastify";
import { AdressService } from "./adress.service";

@Controller("adress")
export class AdressController {
	constructor(private readonly adressService: AdressService) {}

	@Get("/findAdress/:cep")
	async getAdress(@Param("cep") cep: string, @Res() res: FastifyReply) {
		const result = await this.adressService.getAdress(cep);

		if (typeof result == "string")
			return res.status(HttpStatus.BAD_REQUEST).send({ msg: result });

		return res.status(HttpStatus.OK).send(result);
	}
}
