import { NestFactory } from "@nestjs/core";
import {
	FastifyAdapter,
	NestFastifyApplication,
} from "@nestjs/platform-fastify";
import { AppModule } from "./app.module";
// import { UserModule } from "./modules/user.module";
// import { ProductModule } from "./modules/product.module";
// import { PurchaseModule } from "./modules/purchase.module";

async function bootstrap() {
	const app = await NestFactory.create<NestFastifyApplication>(
		AppModule,
		new FastifyAdapter(),
	);
	await app.listen(3000);
}

bootstrap();