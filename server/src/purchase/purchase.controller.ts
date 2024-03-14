import {
	Controller,
	Get,
	Post,
	Body,
	Param,
	HttpStatus,
	Res,
} from "@nestjs/common";
import { PurchaseService } from "./purchase.service";
import { CreatePurchaseDto } from "./dto/create-purchase.dto";
import { FastifyReply } from "fastify";

@Controller("purchase")
export class PurchaseController {
	constructor(private readonly purchaseService: PurchaseService) {}

	@Post()
	async create(
		@Body() createPurchaseDto: CreatePurchaseDto,
		@Res() res: FastifyReply,
	) {
		const result = await this.purchaseService.create(createPurchaseDto);

		if (typeof result == "string")
			return res.status(HttpStatus.BAD_REQUEST).send({ msg: result });

		return res.status(HttpStatus.OK).send(result);
	}

	@Get("/user/:email")
	async findAll(@Param("email") email: string, @Res() res: FastifyReply) {
		const result = await this.purchaseService.findAll(email);

		if (typeof result == "string")
			return res.status(HttpStatus.BAD_REQUEST).send({ msg: result });

		return res.status(HttpStatus.OK).send(result);
	}

	@Get(":id")
	findOne(@Param("id") id: string) {
		return this.purchaseService.findOne(+id);
	}
}
