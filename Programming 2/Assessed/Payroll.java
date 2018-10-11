class Payroll{
  Employee[] emps;
  int nemps;
  
  public Payroll(){
    emps = new Employee[5];
    nemps = 0;
  }
  
  public void addEmployee(String familyName, String givenName, int salary){
   Employee temp = new Employee(familyName, givenName, salary);
   nemps++;
   if(nemps > emps.length){
     Employee[] tempArr = new Employee[emps.length+5];
     for(int i = 0; i < emps.length; i++){
      tempArr[i] = emps[i];
     }
     emps = tempArr;
   }
   emps[nemps-1] = temp;
  }
  
  public Employee highestPaid(){
    Employee highest = emps[0];
    for(int i = 0; i < emps.length; i++){
      if(emps[i].salary > highest.salary){
        highest = emps[i]; 
      }
    }
    return highest;
  }
  
  public void listEmployee(){
    for(int i = 0; i < emps.length; i++){
     System.out.println(emps[i]); 
    }
  }
  
  public int employeeSalary(String surname, String firstname){
    for(int i = 0; i < emps.length; i++){
      if(emps[i].familyName.equals(surname) && emps[i].givenName.equals(firstname)){
       return emps[i].salary; 
      }
    }
    return -1;
  }
  
  public int totalSalary(){
   int allSalary = 0;
   for(int i = 0; i < emps.length; i++){
    allSalary = emps[i].salary + allSalary; 
   }
   return allSalary;
  }
}