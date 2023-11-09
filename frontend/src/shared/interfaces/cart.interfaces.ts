export interface ISelectedProduct {
    domainId: string;
    quantity: number;
}

export interface ICart {
    domainId?: string;
    userI: string;
    selectedProducts: ISelectedProduct[];
    timeStamp?: string;
}
