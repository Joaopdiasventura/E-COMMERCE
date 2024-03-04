import { Test, TestingModule } from '@nestjs/testing';
import { AdressController } from './adress.controller';
import { AdressService } from './adress.service';

describe('AdressController', () => {
  let controller: AdressController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [AdressController],
      providers: [AdressService],
    }).compile();

    controller = module.get<AdressController>(AdressController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
});
