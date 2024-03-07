import { Module } from "@nestjs/common";
import { UserModule } from './user/user.module';
import { ProductModule } from './product/product.module';
import { PurchaseModule } from './purchase/purchase.module';
<<<<<<< HEAD
=======
import { AdressModule } from './adress/adress.module';
>>>>>>> bc4bcc923f3a875aed4361deb38f1c3705336eb7

@Module({
	imports: [UserModule, ProductModule, PurchaseModule, AdressModule],
	controllers:[],
	providers:[]
})
export class AppModule {}