export interface IMedicine{
    id: number;
    name: string;
    medicineStatus: any;
    quantity: number;
    useFor: string[]
    sideEffects: string[],
    ingredients: string[]
}