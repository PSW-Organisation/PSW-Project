import { IPharmacy } from "../pharmacies-view/pharmacy";
import { ITender } from "./tender";

export interface ITenderResponse{
    pharmacy: IPharmacy;
    responseRecieveTime: Date;
    tender: ITender;



} 