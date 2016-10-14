<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>Student System</title>
        <style>
          body {
          margin: 0px;
          padding: 0px;
          widht: 100%;
          height: 100%;
          }

          .student-profile-box {
          display: inline-block;
          margin-left: 2em;
          padding-left: 1em;
          padding-right: 1em;
          border: solid black 1px;
          }

          .heading {
          text-align: center;
          }

          dt {
          font-weight: bold;
          }
        </style>
      </head>
      <body>
        <div class="heading">
          <h1>Students:</h1>
        </div>
        <xsl:for-each select="students/student">
          <div class="student-profile-box">
            <dl>
              <dt>Full Name</dt>
              <dd>
                <xsl:value-of select="name" />
              </dd>
              <dt>Gender</dt>
              <dd>
                <xsl:value-of select="sex" />
              </dd>
              <dt>Date of Birth</dt>
              <dd>
                <xsl:value-of select="birthday" />
              </dd>
              <dt>Faculty Number</dt>
              <dd>
                <xsl:value-of select="facultyNumber" />
              </dd>
              <dt>Phone Number</dt>
              <dd>
                <xsl:value-of select="phone" />
              </dd>
              <dt>E-Mail</dt>
              <dd>
                <xsl:value-of select="email" />
              </dd>
              <dt>Speciality</dt>
              <dd>
                <xsl:value-of select="speciality" />
              </dd>
              <dt>Course</dt>
              <dd>
                <xsl:value-of select="course" />
              </dd>
              <dt>Enrollment Details</dt>
              <xsl:for-each select="enrollmentDetails">                
                <xsl:variable name="isSubmitted" select="endorsement" />
                <dd>
                  <span>Exam date: </span>
                  <xsl:value-of select="concat(substring(examDate, 9, 2), 
                    '/', 
                    substring(examDate, 6, 2),
                    '/', 
                    substring(examDate, 1, 4))" />
                </dd>
                <dd>
                  <span>Score: </span>
                  <xsl:value-of select="score" />
                </dd>
                <dd>
                  <span>Submitted: </span>
                  <xsl:choose>
                    <xsl:when test="$isSubmitted = 'true'">
                    YES
                      </xsl:when>
                  <xsl:otherwise>
                  NO
                  </xsl:otherwise>
                  </xsl:choose>
                </dd>
              </xsl:for-each>
              <dt>Exams held</dt>
              <xsl:for-each select="exams/exam">
                <dd>
                  <span>Discipline: </span>
                  <xsl:value-of select="discipline" />
                </dd>
                <dd>
                  <span>Tutor: </span>
                  <xsl:value-of select="tutor" />
                </dd>
                <dd>
                  <span>Score: </span>
                  <xsl:value-of select="score" />
                </dd>
              </xsl:for-each>
            </dl>
          </div>
        </xsl:for-each>
      </body>
    </html>  
  </xsl:template>
</xsl:stylesheet>