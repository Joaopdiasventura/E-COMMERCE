import { IsNotEmpty } from "class-validator";

export class CreateProductDto {
	@IsNotEmpty({ message: "Campo 'name' não pode ficar vazio" })
	name: string;

	@IsNotEmpty()
	price: number;

	@IsNotEmpty()
	description: string;

	@IsNotEmpty()
	quantity: number;

	@IsNotEmpty({ message: "Campo 'fk_user_email' não pode ficar vazio" })
	fk_user_email: string;
}
