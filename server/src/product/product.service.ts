import { Injectable } from "@nestjs/common";
import { CreateProductDto } from "./dto/create-product.dto";
import { PrismaService } from "src/database/prisma.service";
import { Product } from "./entities/product.entity";
import { UserService } from "src/user/user.service";

@Injectable()
export class ProductService {
	constructor(private readonly prisma: PrismaService) {}
	async create(createProductDto: CreateProductDto) {
		const user = await this.prisma.user.findUnique({
			where: { email: createProductDto.fk_user_email },
		});

		if (!user) return "Usuário não encontrado";

		const existProduct = await this.prisma.product.findFirst({
			where: {
				name: createProductDto.name,
				fk_user_email: createProductDto.fk_user_email,
			},
		});

		if (existProduct)
			return "Você já possui um produto cadastrado com esse nome";

		if (typeof createProductDto.price == "string") {
			createProductDto.price = parseFloat(createProductDto.price);
		}
		if (typeof createProductDto.quantity == "string") {
			createProductDto.quantity = parseInt(createProductDto.quantity);
		}

		const product = await this.prisma.product.create({
			data: { ...createProductDto },
		});
		console.log(product);

		return product;
	}

	async findAll(): Promise<Product[]> {
		return await this.prisma.product.findMany({ orderBy: { id: "desc" } });
	}

	findOne(id: number) {
		return `This action returns a #${id} product`;
	}

	remove(id: number) {
		return `This action removes a #${id} product`;
	}
}
