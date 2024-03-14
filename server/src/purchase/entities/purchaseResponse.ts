import { Product } from "src/product/entities/product.entity";
import { Purchase } from "./purchase.entity";

export default class purchaseResponse {
	purchaseId: Purchase["id"];
	products: Product[];

	constructor(purchaseId: number, products: Product[]) {
		this.purchaseId = purchaseId;
		this.products = products;
	}
}
