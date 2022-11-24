import { IBrand } from "./brand";
import { IProduct } from "./product";
import { IProductType } from "./productType";

export interface IPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IProduct[];
}

export interface IBrandPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IBrand[];
}

export interface IProductTypePagination {
  id: number;
  name: string;
  count: number;
  data: IProductType[];
}
