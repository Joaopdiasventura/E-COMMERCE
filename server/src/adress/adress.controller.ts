import { Controller, Get, Post, Body, Patch, Param, Delete } from '@nestjs/common';
import { AdressService } from './adress.service';

@Controller('adress')
export class AdressController {
  constructor(private readonly adressService: AdressService) {}

  @Get("find/:cep")
  async findAdress(@Param() cep:string) {
    const result = await this.adressService.findAdress(cep);

    if (result[0] == `Exemplos: \"Av. Paulista, São Paulo, SP\" ou \"01311-000\".\n\n`) {
      return {
        message: "Cep não encontrado"
      }
    }

    return result;
  }

  @Get("distance/:cep")
  findDistance() {
    return this.adressService.findDistance();
  }

}