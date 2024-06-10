import { NestFactory } from "@nestjs/core";
import {
	FastifyAdapter,
	NestFastifyApplication,
} from "@nestjs/platform-fastify";
import { AppModule } from "./app.module";

async function bootstrap() {
	const port = process.env.PORT || 3000;

	const app = await NestFactory.create<NestFastifyApplication>(
		AppModule,
		new FastifyAdapter(),
	);

	const corsOptions = {
		origin: [process.env.FRONTEND],
		methods: ["GET", "DELETE", "POST", "PUT"],
		allowedHeaders: ["Content-Type", "Authorization"],
	};

	app.enableCors(corsOptions);

	await app.listen(port, "0.0.0.0");
}

bootstrap();
