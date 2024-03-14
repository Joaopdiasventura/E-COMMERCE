import { Product } from "src/product/entities/product.entity";
import { Purchase } from "./purchase.entity";

export default class createPurchaseResponse {
	purchaseId: Purchase["id"];
	purchaseValue: Purchase["value"];
	products: Product[];

	constructor(purchaseId: Purchase["id"], purchaseValue: Purchase["value"], products: Product[]) {
		this.purchaseId = purchaseId;
		this.purchaseValue = purchaseValue;
		this.products = products;
	}
}
