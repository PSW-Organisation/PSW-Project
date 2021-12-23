import { ITender } from "./tender";
import { ITenderItem } from "./tenderItem"


export interface ITenderResponse{
  tenderItems: ITenderItem[];
  tenderId: number;
  tender: ITender;

}
