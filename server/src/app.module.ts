import { config } from "dotenv";
config();

import { Module } from "@nestjs/common";
import { UserModule } from "./user/user.module";
import { ProductModule } from "./product/product.module";
import { PurchaseModule } from "./purchase/purchase.module";
import { AdressModule } from "./adress/adress.module";

@Module({
	imports: [UserModule, ProductModule, PurchaseModule, AdressModule],
	controllers: [],
	providers: [],
})
export class AppModule {}
