import bcrypt from "bcrypt";
import { Controller, Get, Post, Body, Patch, Param, Delete } from '@nestjs/common';
import { UserService } from './user.service';
import { CreateUserDto } from './dto/create-user.dto';
import { LoginUserDto } from "./dto/login-user.dto";

@Controller('user')
export class UserController {
  constructor(private readonly userService: UserService) {}

  @Post("register")
  async register(@Body() createUserDto: CreateUserDto) {
    return await this.userService.register(createUserDto);
  }

  @Post("login")
  findOne(@Body() LoginUserDto: LoginUserDto) {
    return this.userService.login(LoginUserDto);
  }

  @Delete(':email')
  remove(@Param('email') email: string) {
    return this.userService.remove(email);
  }
}