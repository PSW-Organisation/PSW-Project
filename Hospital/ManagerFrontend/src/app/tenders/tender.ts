import { ITenderItem } from "./tenderItem"
import { ITenderResponse } from "./tenderResponse";


export interface ITender{
    id: number;
    tenderItems: ITenderItem[];
    tenderOpenDate: Date;
    tenderCloseDate: Date;
    open: Boolean;
    tenderResponses: ITenderResponse[];

}