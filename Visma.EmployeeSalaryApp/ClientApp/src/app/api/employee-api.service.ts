import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { EmployeeShift } from '../models/employee-shift';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EmployeeApiService {

  constructor(private httpClient: HttpClient) { 

  }

  public GetEmployeeShifts(employeeId: number, year: number, month: number): Observable<EmployeeShift[]> {
    return this.httpClient.get<EmployeeShift[]>(`/api/employees/${employeeId}/shiftscalculated/${year}-${month}`)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          console.error('Error fetching employee shifts: ', error.error);
          return of([]);
        })
      );
  }
  
  public GetEmployeeSalaryRate(employeeId: number): Observable<number> {
    return this.httpClient.get<number>(`/api/employees/${employeeId}/salary-rate`);
  }


  public GetEmployeeSalaryTotal(employeeId: number, year: number, month: number): Observable<number> {
    return this.httpClient.get<number>(`/api/employees/${employeeId}/shifttotal/${year}-${month}`)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          console.error('Error fetching employee salary total: ', error.error);
          return of(0);
        })
    );
  }
}
