import { Injectable } from "@nestjs/common";
import { CreateProductDto } from "./dto/create-product.dto";
import { PrismaService } from "src/database/prisma.service";
import { Product } from "./entities/product.entity";
import { UserService } from "src/user/user.service";

@Injectable()
export class ProductService {
	constructor(private readonly prisma: PrismaService) {}
	async create(createProductDto: CreateProductDto, quantity: string) {
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

		createProductDto.fk_user_email;
		const products = [];

		for (let i = 0; i < parseInt(quantity); i++) {
			const product = await this.prisma.product.create({
				data: { ...createProductDto, fk_purchase_id: null },
			});
			products.push(product);
		}

		return products;
	}

	async findAll(): Promise<Product[]> {
		return await this.prisma.product.findMany({
			where:{
				fk_purchase_id: null
		},
		 orderBy: { id: "desc" } });
	}

	async findBySeller(email: string): Promise<Product[] | string> {
		try {

			const user = await this.prisma.user.findUnique({where: {email}});

			if (!user) return "Usuário não encontrado"

			const products = await this.prisma.product.findMany({where: {fk_user_email: user.email}});

			return products;
			
		} catch (error) {
			console.log(error);
		}
	}

	async findOne(id:number): Promise<Product | string> {
		try {
			const product = await this.prisma.product.findUnique({where: {id}});
			if(!product) return "Produto não encontrado";

			return product
		} catch (error) {
			console.log(error);
		}
	}

	remove(id: number) {
		return `This action removes a #${id} product`;
	}
}
