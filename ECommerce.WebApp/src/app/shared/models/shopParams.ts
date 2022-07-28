export class ShopParams {
  brandId = 0;
  typeId = 0;
  sort = 'name';
  pageNumber = 1;
  pageSize = 5;
  search = '';
  totalResults = 0;

  getPageRangeLabel(): string {
    return `${this.pageFrom()} - ${this.pageTo()}`;
  }

  pageFrom(): number {
    return ((this.pageNumber - 1) * this.pageSize) + 1;
  }

  pageTo(): number {
    return Math.min((this.pageNumber * this.pageSize), this.totalResults);
  }
}
