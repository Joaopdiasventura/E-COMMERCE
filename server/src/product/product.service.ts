import { Injectable } from '@nestjs/common';
import { CreateProductDto } from './dto/create-product.dto';
import { UpdateProductDto } from './dto/update-product.dto';
import { PrismaService } from 'src/database/prisma.service';
import { Product } from './entities/product.entity';

@Injectable()
export class ProductService {
  constructor(private readonly  prisma: PrismaService) {}
  async create(createProductDto: CreateProductDto) {
    const existProduct = await this.prisma.product.findFirst({
      where:{name: createProductDto.name}
    });

    if (existProduct) return "Já existe um produto cadastrado com esse nome"

    if(typeof createProductDto.price == "string"){
      createProductDto.price = parseFloat(createProductDto.price);
    }
    if(typeof createProductDto.quantity == "string"){
      createProductDto.quantity = parseInt(createProductDto.quantity);
    }

    const product = await this.prisma.product.create({
      data: {...createProductDto},
    });

    return product;
  }

  async findAll():Promise<Product[]> {
    return await this.prisma.product.findMany({orderBy: {id: "desc"}});
  }

  findOne(id: number) {
    return `This action returns a #${id} product`;
  }

  update(id: number, updateProductDto: UpdateProductDto) {
    return `This action updates a #${id} product`;
  }

  remove(id: number) {
    return `This action removes a #${id} product`;
  }
}