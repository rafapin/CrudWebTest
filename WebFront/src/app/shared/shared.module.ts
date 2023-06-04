import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpService } from './services/http.service';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {MatDialogModule} from '@angular/material/dialog';
import { MatCardModule } from '@angular/material/card';
import { MatSlideToggleModule  } from '@angular/material/slide-toggle';
import { MatProgressBarModule  } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule  } from '@angular/material/progress-spinner';



const SHARED_PROVIDER = [
  HttpService
]
const SHARED_MODULES = [
	CommonModule,
  HttpClientModule,
  ReactiveFormsModule,
  MatTableModule,
  MatPaginatorModule,
  MatButtonModule,
  MatIconModule,
  MatFormFieldModule,
  MatInputModule,
  MatDialogModule,
  MatCardModule,
  MatSlideToggleModule ,
  MatProgressBarModule,
  MatProgressSpinnerModule
];

@NgModule({
  declarations: [],
  imports: [
    ...SHARED_MODULES
  ],
  exports:[    
    ...SHARED_MODULES
  ],
	providers: [...SHARED_PROVIDER],
})
export class SharedModule { }
