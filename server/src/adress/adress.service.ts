import { Injectable } from "@nestjs/common";
import { log } from "console";
import puppeteer from "puppeteer";

@Injectable()
export class AdressService {
	async findAdress(param): Promise<string[]> {
		let browser;
    const {cep} = param;
    
		try {
			browser = await puppeteer.launch();

			const page = await browser.newPage();
      await page.goto(`https://cep.guiamais.com.br/cep/${cep}/`);
			await page.setViewport({ width: 1080, height: 1024 });

			const all = await page.evaluate(() => {
        const element = document.querySelector(
          '.elementor-heading-title.elementor-size-default',
        );
        return (element.textContent).split("–");
      });
  
      return all;
		} catch (error) {
			console.error("Ocorreu um erro:", error);
			return null;
		} finally {
			if (browser) {
				await browser.close();
			}
		}
	}

	findDistance() {
		return `This action returns all adress`;
	}
}