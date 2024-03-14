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

	@Get(":email")
	async findOne(@Param("email") email: string, @Res() res: FastifyReply) {
		const result = await this.productService.findOne(email);
		if (typeof result == "string")
			return res.status(HttpStatus.BAD_REQUEST).send({ msg: result });

		return res.status(HttpStatus.OK).send(result);
	}
}