    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyCollege.aspx.cs" Inherits="MyCollege" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Darshan University</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="home">
    <h1 title="Darshan University" runat="server">Darshan University</h1>
    <div>
    <asp:HyperLink ID="hlHome" runat="server" ToolTip="Home"><a href="#home">Home</a></asp:HyperLink>
    <asp:HyperLink ID="hlAboutUniversity" runat="server" ToolTip="About University"><a href="#aboutUniversity">About University</a></asp:HyperLink>
    <asp:HyperLink ID="hlCoursesRunByUniversity" runat="server" ToolTip="Courses Run by Unviersity"><a href="#coursesRun">Courses Run by Unviersity</a></asp:HyperLink>
    <asp:HyperLink ID="hlDepartment" runat="server" ToolTip="Departments"><a href="#departments">Department</a></asp:HyperLink>
    <asp:HyperLink ID="hlStaffMembers" runat="server" ToolTip="Staff Members"><a href="#staffMembers">Staff Members</a></asp:HyperLink>
    <asp:HyperLink ID="hlNews" runat="server" ToolTip="News"><a href="#news">News</a></asp:HyperLink>
    <asp:HyperLink ID="hlContact" runat="server" ToolTip="Contact Us"><a href="#contact">Contact Us</a></asp:HyperLink><br /><br />
    </div>
        <div>
    <h2 id="aboutUniversity" title="About University"><u>About University</u></h2>
        <p>Darshan University (DU), is a prominent organization offering a broad slate of academic programs and professional courses for undergraduate, graduate and postgraduate programs in Engineering, Science & Technology.
           The University is located in peaceful and sylvan surroundings with distinctive collegiate structure, about 19 km from Rajkot, Gujarat, India. It was established as an Engineering Institute in the year 2009, by Shree G. N. Patel Education & Charitable Trust with the objective to impart quality education and training in various fields of Engineering and Technology.
           It has now been transformed to the DARSHAN UNIVERSITY through an Act by the Government of Gujarat under Gujarat State Private Universities (Amendment) Act, 2021 (Act no. 15).
            
            <br /><br />From its inception, the organization has grown steadily and created a unique identity in the field of Engineering & Technology by implementing skill and training-based
           foundation for education. The academic environment at the campus creates an ambience to promote creativity and exploration of technical skills. Darshan University is committed to the generation of knowledge, innovations and its contribution
           towards the development of the Nation.</p><br />

        <p>Darshan University (DU), is a prominent organization offering a broad slate of academic programs and professional courses for undergraduate, graduate and postgraduate programs in Engineering, Science & Technology.
           The University is located in peaceful and sylvan surroundings with distinctive collegiate structure, about 19 km from Rajkot, Gujarat, India. It was established as an Engineering Institute in the year 2009, by Shree G. N. Patel Education & Charitable Trust with the objective to impart quality education and training in various fields of Engineering and Technology.
           It has now been transformed to the DARSHAN UNIVERSITY through an Act by the Government of Gujarat under Gujarat State Private Universities (Amendment) Act, 2021 (Act no. 15).
            
            <br /><br />From its inception, the organization has grown steadily and created a unique identity in the field of Engineering & Technology by implementing skill and training-based
           foundation for education. The academic environment at the campus creates an ambience to promote creativity and exploration of technical skills. Darshan University is committed to the generation of knowledge, innovations and its contribution
           towards the development of the Nation.</p><br />

        <p>Darshan University (DU), is a prominent organization offering a broad slate of academic programs and professional courses for undergraduate, graduate and postgraduate programs in Engineering, Science & Technology.
           The University is located in peaceful and sylvan surroundings with distinctive collegiate structure, about 19 km from Rajkot, Gujarat, India. It was established as an Engineering Institute in the year 2009, by Shree G. N. Patel Education & Charitable Trust with the objective to impart quality education and training in various fields of Engineering and Technology.
           It has now been transformed to the DARSHAN UNIVERSITY through an Act by the Government of Gujarat under Gujarat State Private Universities (Amendment) Act, 2021 (Act no. 15).
            
            <br /><br />From its inception, the organization has grown steadily and created a unique identity in the field of Engineering & Technology by implementing skill and training-based
           foundation for education. The academic environment at the campus creates an ambience to promote creativity and exploration of technical skills. Darshan University is committed to the generation of knowledge, innovations and its contribution
           towards the development of the Nation.</p><br />
            </div>
        <div>
        <h2 id="coursesRun" title="Courses Run by Unviersity"><u>Courses Run by University</u></h2>
            <ul>
                <li>Diploma (After 10th)</li>
                <li>UG(After 12th)</li>
                <li>PG</li>
                <li>Ph.D</li>
            </ul>
            </div>

        <br />
        <div>
        <h2 id="departments" title="Departments"><u>Departments</u></h2>
        <ul>
            <li>School Of Computer Science</li>
            <li>School Of Engineering</li>
            <li>School of Diploma Engineering</li>
            <li>School of Management</li>
            <li>School of Science</li>
        </ul>
        </div>
        <div>
            <h2 id="staffMembers" title="Staff Members"><u>Staff Members</u></h2>
            <ul>
                <li>Dr. Gopi Sangani (Ph.D. , M.E. (CE))<br />
                    -Head of Department (CE)
                </li><br />
                <li>Dr. Nilesh Gambhva Ph.D. , M.E. (CE)<br />-Professor</li><br />
                <li>Dr. Jadeja Pradyumansinh Ph.D., M.E. (CE)<br />-Associate Professor</li><br />
                <li>Prof. Firoz Sherasiya M.E (CE)<br />-Assistant Professor</li><br />
            </ul>
        </div>
        <div>
            <h2 title="News" id="news"><u>News</u></h2>
            <div>
            <h3 title="Frolic">Frolic - Techfest</h3>
                <p>Frolic is National Level Technical Symposium where talent meets opportunity. Technical fests should be an essential part of course curriculum as it gives a platform to young brains to showcase their innovative ideas and compete with their peers.<br /><br />

                These technical fests are an amalgamation of fun and learning where spectacular ideas are displayed, and students learn and feel inspired. These events guide engineers, computer experts, researchers to dream bigger and achieve them.
                Frolic hosts technical competitions and events covering all areas of engineering are organized every year in the first week of September, where students participate enthusiastically to make the Tech-Fest a success.</p>
            <asp:Image ID="imgFrolic" runat="server" ToolTip="Frolic" AlternateText="Frolic - Techfest" ImageUrl="https://darshan.ac.in/U01/Page/30---16-06-2021-03-58-33.jpeg" Width="500px"/>
            </div>
            <div>
            <h3 title="Udaan">Udaan - Cultural Festival</h3>
                <p>Udaan is an annual cultural festival. It usually takes place in the second week of April. This consists of literary and debating events/competitions like singing, dance, play, mimicry, garba, etc. Students put in their best efforts to make college fests entertaining and exciting. These multiple cultural events, technical fests, celebrity performances, competitions, partying with friends make you confident and job-ready.<br /><br />

                    These amazing college fests play a significant role in shaping the career of a student, read on to know-how. Students who volunteer and organize college fests display their self-starter attitude. Students also develop four essential skills from organizing fests – planning, teamwork, leadership, and multi-tasking
                    They also learn how to balance personal and professional life which helps in differentiating between doers and dreamers.</p>
                <asp:Image ID="imgUdaan" runat="server" ToolTip="Udaan Image" AlternateText="Udaan - Cultural Festival" ImageUrl="https://darshan.ac.in/U01/Page/30---18-06-2021-10-19-11.jpeg" Width="500px"/>

            </div>
        </div>
        <div>
            <h2 id="contact" title="Contact Us"><u>Contact Us</u></h2>
            <h3>Contact No. :</h3>
            +91 - 97277 47310<br />
            +91 - 97277 47311

            <h3>Location :</h3>
            Rajkot - Morbi Highway,<br />
Rajkot - 363650, Gujarat (INDIA)
        </div>
    </div>
    </form>
</body>
</html>
