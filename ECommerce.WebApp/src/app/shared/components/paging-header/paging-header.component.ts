import {AfterViewInit, Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-paging-header',
  templateUrl: './paging-header.component.html',
  styleUrls: ['./paging-header.component.scss']
})
export class PagingHeaderComponent implements OnInit {
  @Input() pageRangeLabel: string;
  @Input() totalResults: number;

  constructor() {
  }

  ngOnInit(): void {

  }
}
