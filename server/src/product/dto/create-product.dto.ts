import { IsNotEmpty } from "class-validator";

export class CreateProductDto {
	@IsNotEmpty({ message: "Campo 'name' não pode ficar vazio" })
	name: string;

	@IsNotEmpty({ message: "Campo 'price' não pode ficar vazio" })
	price: number;

	@IsNotEmpty({ message: "Campo 'description' não pode ficar vazio" })
	description: string;

	@IsNotEmpty({ message: "Campo 'fk_user_email' não pode ficar vazio" })
	fk_user_email: string;
}
