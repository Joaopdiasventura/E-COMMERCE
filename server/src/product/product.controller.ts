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

	@Post()
	async create(
		@Body() createProductDto: CreateProductDto,
		@Res() res: FastifyReply,
	) {
		const result = await this.productService.create(createProductDto);

		if (typeof result == "string")
			return res.status(HttpStatus.BAD_REQUEST).send({ msg: result });

		return res.status(201).send(result);
	}

	@Get()
	findAll() {
		return this.productService.findAll();
	}

	@Get(":id")
	findOne(@Param("id") id: string) {
		return this.productService.findOne(+id);
	}
}
