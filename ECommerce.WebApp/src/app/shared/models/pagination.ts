import {IProduct} from "./product";

export interface IPagination {
  pageIndex: number;
  pageSize: number;
  totalPages: number;
  totalResults: number;
  data: IProduct[];
}
