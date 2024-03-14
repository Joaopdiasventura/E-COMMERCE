import { Injectable } from "@nestjs/common";
import { CreatePurchaseDto } from "./dto/create-purchase.dto";
import { PrismaService } from "src/database/prisma.service";
import { Product } from "src/product/entities/product.entity";
import createPurchaseResponse from "./entities/createPurchaseResponse";
import { getPurchaseResponse } from "./entities/getPurchaseResponse";

@Injectable()
export class PurchaseService {
	constructor(private readonly prisma: PrismaService) {}
	async create(createPurchaseDto: CreatePurchaseDto) {
		try {
			const user = await this.prisma.user.findUnique({
				where: { email: createPurchaseDto.fk_user_email },
			});
			
			if (!user) return "Usuário não encontrado";

			const purchase = await this.prisma.purchase.create({
				data: { fk_user_email: user.email },
			});

			let value = 0;
			const products: Product[] = [];

			for (let i = 0; i < createPurchaseDto.products.length; i++) {
				const product = await this.prisma.product.findUnique({
					where: { id: createPurchaseDto.products[i].fk_product_id },
				});

				if (!product || product.fk_purchase_id != null) {
					await this.prisma.product.updateMany({
						where: { fk_purchase_id: purchase.id },
						data: { fk_purchase_id: purchase.id },
					});
					await this.prisma.purchase.delete({
						where: { id: purchase.id },
					});
					return "Produto não encontrado.... COMPRA CANCELADA";
				}

				await this.prisma.product.update({
					where: { id: product.id },
					data: { fk_purchase_id: purchase.id },
				});

				value += product.price;
				
				const seller = await this.prisma.user.findUnique({
					where: { email: product.fk_user_email },
				});
				seller.money += product.price;

				await this.prisma.user.update({
					where: { email: product.fk_user_email },
					data: { money: (seller.money += product.price) },
				});

				products.push(product);
			}

			if (products.length == 0) {
				await this.prisma.purchase.delete({where: {id: purchase.id}});
				return "Compra cancelada por não possuir nenhum item";
			}

			await this.prisma.purchase.update({
				where: { id: purchase.id },
				data: { value: value },
			});

			await this.prisma.user.update({
				where: { email: user.email },
				data: { money: (user.money -= value) },
			});

			return new createPurchaseResponse(purchase.id, value, products);
		} catch (error) {
			console.log(error);
			
		}
	}

	async findAll(email: string) {
		const user = await this.prisma.user.findUnique({where: {email}});

		if (!user) return "Usuário não encontrado";
		const purchase = await this.prisma.purchase.findMany({where: {fk_user_email: user.email}, orderBy: {id: "desc"}});

		const result = [];
		for (let i = 0; i < purchase.length; i++) {
			const products = await this.prisma.product.findMany({where: {fk_purchase_id: purchase[i].id}, orderBy: {id: "desc"}});
			result.push(new getPurchaseResponse(purchase[i], products));
		}
		return result;
	}

	findOne(id: number) {
		return `This action returns a #${id} purchase`;
	}
}
