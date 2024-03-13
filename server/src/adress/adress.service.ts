import { Injectable } from "@nestjs/common";
import axios from "axios";

@Injectable()
export class AdressService {
	async getAdress(cep: string) {
		const key = process.env.GOOGLE_KEY;
		const result = await axios
			.get(
				`https://maps.googleapis.com/maps/api/geocode/json?latlng=40.714224,-73.961454&location_type=ROOFTOP&result_type=street_address&address=${cep}&language=pt-br&key=${key}`,
			)
			.then((result) => result.data);

            const components = result.results[0].address_components;
            
		if (result.status == "OK") {
            return {
                street: components[1].long_name,
                neighborhood: components[2].long_name,
                city: components[3].long_name,
                state: components[4].long_name,
                county: components[5].long_name
            }
		}
	}
}