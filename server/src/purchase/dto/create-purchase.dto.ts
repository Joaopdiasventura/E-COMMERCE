import { IsNotEmpty } from "class-validator";
import createPurchaseProductDto from "./create_purchase_product.dto";

export class CreatePurchaseDto {
	@IsNotEmpty()
	fk_user_email: string;

	@IsNotEmpty()
	products: createPurchaseProductDto[];
}
