import { Component, OnInit } from '@angular/core';
import { TopSellerReport } from './seller-report.model';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-seller-report',
  imports: [
    CommonModule,
    MatTableModule,
    MatProgressBarModule,
    MatCardModule,
  ],
  templateUrl: './seller-report.component.html',
  styleUrl: './seller-report.component.scss'
})
export class SellerReportComponent implements OnInit {
  loading: boolean = false;
  initialLoad: boolean = true;
  topSellers: TopSellerReport[] = [];
  ds = new MatTableDataSource<TopSellerReport>();
  constructor(private http: HttpClient) {}

  ngOnInit(): void {}

  onBranchSelected(branch: string): void {
    this.initialLoad = false;
    this.loading = true;

    this.http.get<TopSellerReport[]>(`http://localhost:5139/PerformanceReport?branch=${branch}`)
      .subscribe({
        next: (sellers) => {
          setTimeout(()=>this.loading = false, 1000);
          this.topSellers = sellers;
        },
        error: () => {
          this.loading = false;
          this.topSellers = [];
        }
      })
  }
}
