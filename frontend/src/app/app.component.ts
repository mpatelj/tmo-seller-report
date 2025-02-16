import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BranchFilterComponent } from "./components/branch-filter/branch-filter.component";
import { SellerReportComponent } from './components/seller-report/seller-report.component';
import {MatToolbarModule} from '@angular/material/toolbar';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet, 
    BranchFilterComponent, 
    SellerReportComponent,
    MatToolbarModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'seller-report';
}
