import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../api.service';
import { ITheme } from '../../shared/interfaces/theme';

@Component({
  selector: 'app-theme-list',
  templateUrl: './theme-list.component.html',
  styleUrls: ['./theme-list.component.scss'],
})
export class ThemeListComponent implements OnInit {
  constructor(private apiService: ApiService) {}

  themeList: ITheme[] | null = null;
  errorFetchingData = false;

  ngOnInit(): void {
    this.apiService.loadThemes().subscribe({
      next: (value) => {
        this.themeList = value;
      },
      error: (err) => {
        this.errorFetchingData = true;
        console.error(err);
      },
    });
  }
}
