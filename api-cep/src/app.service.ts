import { Injectable } from "@nestjs/common";
import puppeteer from "puppeteer";

@Injectable()
export class AppService {

  async findCep(param) {
    let browser;
    const { cep } = param;
    console.log(cep);    

    try {
      browser = await puppeteer.launch();
      const adress = `https://cep.guiamais.com.br/cep/${cep.trim()}/`;

      const page = await browser.newPage();
      await page.goto(adress);
      await page.setViewport({ width: 1080, height: 1024 });

      const all = await page.evaluate(() => {
        const element = document.querySelector(
          ".elementor-heading-title.elementor-size-default",
        );
        const informations = element.textContent.split("–");

        informations[3] = informations[3].split(" ")[1];
        return informations;
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

  async findDistance (params){
    let browser;
    const { cep1, cep2 } = params;
    
    try {
      browser = await puppeteer.launch();
      const adress = `https://www.google.com/search?q=distancia+entre+o+cep+${cep1}+e+${cep2}`;
  
      const page = await browser.newPage();
      await page.goto(adress);
      await page.setViewport({ width: 1080, height: 1024 });

      const all = await page.evaluate(() => {
        const element = ((((document.querySelector(".UdvAnf").textContent).split("("))[1]).split("k"))[0];
        if (element) {
          return element
        }
        return "Não foi possivel calcular a dstância";
      });
      console.log(all);
      
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
}
