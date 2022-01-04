import { IMedicine } from "./medicine";
import { ITenderResponse } from "./tenderResponses";

export interface ITender{
    id: any;
   medicineTransactions: IMedicine[];
    tenderOpenDate: Date;
    tenderCloseDate: Date;
    open: Boolean;
    tenderResponses: ITenderResponse[];

}