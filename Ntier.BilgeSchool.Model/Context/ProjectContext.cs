using Ntier.BilgeSchool.Core.Entity;
using Ntier.BilgeSchool.Model.Entity;
using Ntier.BilgeSchool.Model.Entity.Enum;
using Ntier.BilgeSchool.Model.Maps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "server=.;database=BilgeSchoolDB;uid=sa;pwd=123";
            Database.SetInitializer(new BilgeSchoolDB());
        }
        public DbSet<Announcement> Announcements  { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Course>  Courses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<CourseNote> CoursesNotes { get; set; }
        public DbSet<Classroom> Classrooms{ get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseCode> CourseCodes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<EducationSchedule> EducationSchedules { get; set; }
        public DbSet<EducationYear> EducationYears { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SuccessList>  SuccessLists { get; set; }
        public class BilgeSchoolDB : CreateDatabaseIfNotExists<ProjectContext>
        {
            #region SeedData
            protected override void Seed(ProjectContext context)
            {
                #region Classroom
                
                context.Classrooms.Add(new Classroom { ID = 1, ClassroomName = "1.Sınıf" });
                context.Classrooms.Add(new Classroom { ID = 2, ClassroomName = "2.Sınıf" });
                context.Classrooms.Add(new Classroom { ID = 3, ClassroomName = "3.Sınıf" });
                context.Classrooms.Add(new Classroom { ID = 4, ClassroomName = "4.Sınıf" });
                #endregion

                #region Section
              
                context.Sections.Add(new Section { ID = 1, SectionName = "IX-A", ClassroomId = 1 });
                context.Sections.Add(new Section { ID = 2, SectionName = "IX-B", ClassroomId = 1 });
                context.Sections.Add(new Section { ID = 3, SectionName = "IX-C", ClassroomId = 1 });
                context.Sections.Add(new Section { ID = 4, SectionName = "X-A", ClassroomId = 2 });
                context.Sections.Add(new Section { ID = 5, SectionName = "X-B", ClassroomId = 2 });
                context.Sections.Add(new Section { ID = 6, SectionName = "X-C", ClassroomId = 2 });
                context.Sections.Add(new Section { ID = 7, SectionName = "XI-A", ClassroomId = 3 });
                context.Sections.Add(new Section { ID = 8, SectionName = "XI-B", ClassroomId = 3 });
                context.Sections.Add(new Section { ID = 9, SectionName = "XI-C", ClassroomId = 3 });
                context.Sections.Add(new Section { ID = 10, SectionName = "XII-A", ClassroomId = 4 });
                context.Sections.Add(new Section { ID = 11, SectionName = "XII-B", ClassroomId = 4 });
                context.Sections.Add(new Section { ID = 12, SectionName = "XII-C", ClassroomId = 4 });
                #endregion

                #region Period
          
                context.Periods.Add(new Period { ID = 1, PeriodName = "1.Dönem", StartedPeriod = new DateTime(2019, 09, 16), FinishedPeriod = new DateTime(2020, 01, 31), EducationYearId = 1 });
                context.Periods.Add(new Period { ID = 2, PeriodName = "2.Dönem", StartedPeriod = new DateTime(2020, 02, 17), FinishedPeriod = new DateTime(2020, 06, 12), EducationYearId = 1 });
                #endregion

                #region Education Years
              
                context.EducationYears.Add(new EducationYear { ID = 1, EducationYearName = "2019-2020 Eğitim Öğretim Yılı" });
                #endregion

                #region Courses
                
                context.Courses.Add(new Course { ID = 1, CourseName = "Biyoloji", CourseHour = 5, PeriodId = 1, EducationYearId = 1 });
                context.Courses.Add(new Course { ID = 2, CourseName = "Matematik", CourseHour = 5, PeriodId = 1, EducationYearId = 1 });
                context.Courses.Add(new Course { ID = 3, CourseName = "Fizik", CourseHour = 5, PeriodId = 1, EducationYearId = 1 });
                context.Courses.Add(new Course { ID = 4, CourseName = "Türkçe", CourseHour = 5, PeriodId = 1, EducationYearId = 1 });
                context.Courses.Add(new Course { ID = 5, CourseName = "Tarih", CourseHour = 5, PeriodId = 1, EducationYearId = 1 });
                context.Courses.Add(new Course { ID = 6, CourseName = "İngilizce", CourseHour = 5, PeriodId = 1, EducationYearId = 1 });
                context.Courses.Add(new Course { ID = 7, CourseName = "Kimya", CourseHour = 5, PeriodId = 1, EducationYearId = 1 });
                #endregion

                #region CourseCode
                
                context.CourseCodes.Add(new CourseCode { ID = 1, CourseCodeName = "BİY-1", CourseId = 1 });
                context.CourseCodes.Add(new CourseCode { ID = 2, CourseCodeName = "BİY-2", CourseId = 1 });
                context.CourseCodes.Add(new CourseCode { ID = 3, CourseCodeName = "MAT-1", CourseId = 2 });
                context.CourseCodes.Add(new CourseCode { ID = 4, CourseCodeName = "MAT-2", CourseId = 2 });
                context.CourseCodes.Add(new CourseCode { ID = 5, CourseCodeName = "FİZ-1", CourseId = 3 });
                context.CourseCodes.Add(new CourseCode { ID = 6, CourseCodeName = "FİZ-2", CourseId = 3 });
                context.CourseCodes.Add(new CourseCode { ID = 7, CourseCodeName = "TÜR-1", CourseId = 4 });
                context.CourseCodes.Add(new CourseCode { ID = 8, CourseCodeName = "TÜR-2", CourseId = 4 });
                context.CourseCodes.Add(new CourseCode { ID = 9, CourseCodeName = "TAR-1", CourseId = 5 });
                context.CourseCodes.Add(new CourseCode { ID = 10, CourseCodeName = "TAR-2", CourseId = 5 });
                context.CourseCodes.Add(new CourseCode { ID = 11, CourseCodeName = "İNG-1", CourseId = 6 });
                context.CourseCodes.Add(new CourseCode { ID = 12, CourseCodeName = "İNG-2", CourseId = 6 });
                context.CourseCodes.Add(new CourseCode { ID = 13, CourseCodeName = "KİM-1", CourseId = 7 });
                context.CourseCodes.Add(new CourseCode { ID = 14, CourseCodeName = "KİM-2", CourseId = 7 });
                #endregion

                #region AppUser
                
                context.AppUsers.Add(new AppUser { ID = 1, UserName = "admin", Password = "1234", ConfirmPassword = "1234", FirstName = "admin", LastName = "admin", Role = Role.Admin });
                context.AppUsers.Add(new AppUser { ID = 2, UserName = "teacher", Password = "1234", ConfirmPassword = "1234", FirstName = "teacher", LastName = "teacher", Role = Role.Teacher });
                context.AppUsers.Add(new AppUser { ID = 3, UserName = "student", Password = "1234", ConfirmPassword = "1234", FirstName = "student", LastName = "student", Role = Role.Student });
                #endregion

                #region Branch
                
                context.Branches.Add(new Branch { ID = 1, BranchName = "Matematik" });
                context.Branches.Add(new Branch { ID = 2, BranchName = "Fizik" });
                context.Branches.Add(new Branch { ID = 3, BranchName = "Yabancı Dil" });
                context.Branches.Add(new Branch { ID = 4, BranchName = "Türkçe" });
                context.Branches.Add(new Branch { ID = 5, BranchName = "Biyoloji" });
                #endregion

                #region Teacher
                
                context.Teachers.Add(new Teacher { ID = 1, TeacherName = "Ali", TeacherLastName = "Doğru", BranchId = 1, TCKN = 11111111111, DutyName = "Öğretmen", CourseId = 2 });
                context.Teachers.Add(new Teacher { ID = 2, TeacherName = "Zeynep", TeacherLastName = "Medel", BranchId = 5, TCKN = 22222222222, DutyName = "Öğretmen", CourseId = 1 });
                context.Teachers.Add(new Teacher { ID = 3, TeacherName = "Hasan", TeacherLastName = "Nokta", BranchId = 4, TCKN = 33333333333, DutyName = "Öğretmen", CourseId = 4 });
                context.Teachers.Add(new Teacher { ID = 4, TeacherName = "Aslı", TeacherLastName = "Güzel", BranchId = 3, TCKN = 44444444444, DutyName = "Öğretmen", CourseId = 6 });
                #endregion

                #region Student

                context.Students.Add(new Student { StudentName = "Ali", StudentLastName = "Doğru",StudentNumber="101-20", GraduatedSchool = " Atatürk İlkÖğretim Okulu", Gender = Gender.Erkek, AverageGrade = 4, FamilyId = 1 });
                context.Students.Add(new Student { StudentName = "Veli", StudentLastName = "Yanlış", StudentNumber = "102-20", GraduatedSchool = " Atatürk İlkÖğretim Okulu", Gender = Gender.Erkek, AverageGrade = 5, FamilyId = 2 });
                context.Students.Add(new Student { StudentName = "Zeynep", StudentLastName = "Haklı", StudentNumber = "103-20", GraduatedSchool = " Atatürk İlkÖğretim Okulu", Gender = Gender.Kız, AverageGrade = 6, FamilyId = 3 });
                context.Students.Add(new Student { StudentName = "Fatma", StudentLastName = "Güzel", StudentNumber = "104-20", GraduatedSchool = " Atatürk İlkÖğretim Okulu", Gender = Gender.Kız, AverageGrade = 6, FamilyId = 4 });

                #endregion

                #region Family

                context.Families.Add(new Family { ID = 1, Name = "Hasan", LastName = "Doğru", PhoneNumber = "05455434545", Adress = "A Mah.,B Cad.,C Sok. Kadiköy/İstanbul" });
                context.Families.Add(new Family { ID = 2, Name = "Mustafa", LastName = "Yanlış", PhoneNumber = "05455434646", Adress = "C Mah.,A Cad.,B Sok. Maltepe/İstanbul" });
                context.Families.Add(new Family { ID = 3, Name = "Ayşe", LastName = "Haklı", PhoneNumber = "05455434747", Adress = "B Mah.,C Cad.,A Sok. Küçükyalı/İstanbul" });
                context.Families.Add(new Family { ID = 4, Name = "Leyla", LastName = "Güzel", PhoneNumber = "05455434848", Adress = "D Mah.,E Cad.,F Sok. Bostancı/İstanbul" });
                #endregion





                base.Seed(context);


            }
            #endregion
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AttendanceMap());
            modelBuilder.Configurations.Add(new CourseMap());
            modelBuilder.Configurations.Add(new ClassroomMap());
            modelBuilder.Configurations.Add(new FamilyMap());
            modelBuilder.Configurations.Add(new PeriodMap());
            modelBuilder.Configurations.Add(new SectionMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new CourseCodeMap());
            modelBuilder.Configurations.Add(new TeacherMap());
            modelBuilder.Configurations.Add(new EducationYearMap());
            modelBuilder.Configurations.Add(new EducationScheduleMap());
            modelBuilder.Configurations.Add(new SuccessListMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new HomeworkMap());
            modelBuilder.Configurations.Add(new AnnouncementMap());
            modelBuilder.Configurations.Add(new BranchMap());
            modelBuilder.Configurations.Add(new CourseNoteMap());
            modelBuilder.Configurations.Add(new AppUserMap());

            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            var modifierEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();
            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;

            int user = 1;
            string ip = "192.168.1.1";

            foreach (var item in modifierEntries)
            {
                var entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    entity.CreatedAdUserName = identity;
                    entity.CreatedComputerName = computerName;
                    entity.CreatedDate = dateTime;
                    entity.CreatedBy = user;
                    entity.CreatedIP = ip;
                }
                else if (item.State == EntityState.Modified)
                {
                    entity.ModifiedAdUserName = identity;
                    entity.ModifiedComputerName = computerName;
                    entity.ModifiedDate = dateTime;
                    entity.ModifiedBy = user;
                    entity.ModifiedIP = ip;
                }
            }
            return base.SaveChanges();  
        }
    }
}
