import { Injectable } from "@nestjs/common";
import { CreatePurchaseDto } from "./dto/create-purchase.dto";
import { PrismaService } from "src/database/prisma.service";
import { Product } from "src/product/entities/product.entity";
import purchaseResponse from "./entities/purchaseResponse";

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

				if (!product)
					return "Produto não encontrado.... COMPRA CANCELADA";

				createPurchaseDto.products[i].fk_purchase_id = purchase.id;

				await this.prisma.purchase_product.create({
					data: { ...createPurchaseDto.products[i] },
				});

				await this.prisma.product.update({
					where: { id: product.id },
					data: { quantity: (product.quantity -= 1) },
				});
				console.log(product.quantity);

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

			purchase.value = value;
			await this.prisma.purchase.update({
				where: { id: purchase.id },
				data: { value },
			});

			await this.prisma.user.update({
				where: { email: user.email },
				data: { money: (user.money -= value) },
			});

			return new purchaseResponse(purchase.id, products);
		} catch (error) {}
	}

	findAll() {
		return `This action returns all purchase`;
	}

	findOne(id: number) {
		return `This action returns a #${id} purchase`;
	}
}
