import { Controller, Get, Param } from "@nestjs/common";
import { AdressService } from "./adress.service";

@Controller("adress")
export class AdressController {
	constructor(private readonly adressService: AdressService) {}

	@Get("/findAdress/:cep")
	async getAdress(@Param("cep") cep: string) {
		return await this.adressService.getAdress(cep);
	}
}
