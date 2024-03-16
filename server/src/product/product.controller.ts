import {
	Controller,
	Get,
	Post,
	Body,
	Param,
	Res,
	HttpStatus,
} from "@nestjs/common";
import { FastifyReply } from "fastify";
import { ProductService } from "./product.service";
import { CreateProductDto } from "./dto/create-product.dto";

@Controller("product")
export class ProductController {
	constructor(private readonly productService: ProductService) {}

	@Post(":qnt")
	async create(
		@Body() createProductDto: CreateProductDto,
		@Res() res: FastifyReply,
		@Param("qnt") qnt: string,
	) {
		const result = await this.productService.create(createProductDto, qnt);

		if (typeof result == "string")
			return res.status(HttpStatus.BAD_REQUEST).send({ msg: result });

		return res.status(HttpStatus.CREATED).send(result);
	}

	@Get()
	findAll() {
		return this.productService.findAll();
	}

	@Get("/seller/:email")
	async findBySeller(@Param("email") email: string, @Res() res: FastifyReply) {
		const result = await this.productService.findBySeller(email);
		if (typeof result == "string")
			return res.status(HttpStatus.BAD_REQUEST).send({ msg: result });

		return res.status(HttpStatus.OK).send(result);
	}

	@Get("/id/:id")
	async findOne(@Param("id") id: number, @Res() res: FastifyReply){
		const result = await this.productService.findOne(id);
		if (typeof result == "string")
			return res.status(HttpStatus.BAD_REQUEST).send({ msg: result });

		return res.status(HttpStatus.OK).send(result);
	}
}