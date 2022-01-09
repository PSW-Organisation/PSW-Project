import { ITenderItem } from "./tenderItem"


export interface ITender{
    id: number;
    tenderItems: ITenderItem[];
    tenderOpenDate: Date;
    tenderCloseDate: Date;
    open: Boolean;
    isWon: Boolean;

}
