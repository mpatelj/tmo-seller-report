import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-branch-filter',
  imports: [
    MatFormFieldModule,
    MatOptionModule,
    MatSelectModule,
    CommonModule
  ],
  templateUrl: './branch-filter.component.html',
  styleUrl: './branch-filter.component.scss',
  standalone: true,
})
export class BranchFilterComponent implements OnInit {
  branches: string[] = [];
  selectedBranch: string | undefined;

  @Output() branchSelected = new EventEmitter<string>();
  
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getBranches();
  }

  getBranches(): void {
    this.http.get<string[]>('http://localhost:5139/PerformanceReport/branches')
      .subscribe({
        next: (data) => {
          this.branches = data;
        },
        error: (err) => {
          console.error('Error fetching branches:', err)
        }
      });
  }

  onBranchChange(branch: string): void {
    this.selectedBranch = branch;
    this.branchSelected.emit(this.selectedBranch);
  }
}
