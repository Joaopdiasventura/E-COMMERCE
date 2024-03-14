import { Product } from "src/product/entities/product.entity";
import { Purchase } from "./purchase.entity";

export class getPurchaseResponse {
    purchase: Purchase;
    products: Product[];

    constructor(purchase: Purchase, products: Product[]){
        this.purchase = purchase;
        this.products = products;
    }
}