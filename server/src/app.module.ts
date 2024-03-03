import { Module } from "@nestjs/common";
import { UserModule } from './user/user.module';
import { ProductModule } from './product/product.module';
import { PurchaseModule } from './purchase/purchase.module';

@Module({
	imports: [UserModule, ProductModule, PurchaseModule],
	controllers:[],
	providers:[]
})
export class AppModule {}