import { Module } from '@nestjs/common';
import { AdressService } from './adress.service';
import { AdressController } from './adress.controller';

@Module({
  controllers: [AdressController],
  providers: [AdressService],
})
export class AdressModule {}
