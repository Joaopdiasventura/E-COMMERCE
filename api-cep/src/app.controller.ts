import { Controller, Get, Param } from "@nestjs/common";
import { AppService } from "./app.service";

@Controller()
export class AppController {
  constructor(private readonly appService: AppService) {}

  @Get("find/:cep")
  async findAdress(@Param() cep:string) {
    
    try {
      const result = await this.appService.findCep(cep);
  
      if (result[0] == `Exemplos: \"Av. Paulista, São Paulo, SP\" ou \"01311-000\".\n\n`) {
        return {
          message: "Cep não encontrado"
        }
      }
  
      return result;
    } catch (error) {
      console.log(error);
    }
  }

  @Get("distance/:cep1/:cep2")
  async findDistance (@Param() cep:string){
    try {
      const result = await this.appService.findDistance(cep);
      return result;
    } catch (error) {
      console.log(error);
    }
  }
}
