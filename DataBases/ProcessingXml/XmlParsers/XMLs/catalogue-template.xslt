<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>Catalogue</title>
        <style>
          body {
          margin: 0px;
          padding: 0px;
          }

          .heading {
          text-align: center;
          }

          dt {
          font-weight: bold;
          }

          .content-box {
          display: inline-block;
          vertical-align: text-top;
          margin-top: 0px;
          margin-left: 2em;
          padding-left: 2em;
          padding-right: 2em;
          }

          .track {
          font-style: italic;
          }
        </style>
      </head>
      <body>
        <div class="heading">
          <h1>Music Catalogue</h1>
        </div>
        <xsl:for-each select="/catalogue/album">
          <div class="content-box">
            <dt>Album name</dt>
            <dd>
              <xsl:value-of select="title"/>
            </dd>
            <dt>Artist</dt>
            <dd>
              <xsl:value-of select="artist"/>
            </dd>
            <dt>Year</dt>
            <dd>
              <xsl:value-of select="year"/>
            </dd>
            <dt>Producer</dt>
            <dd>
              <xsl:value-of select="producer"/>
            </dd>
            <dt>Price</dt>
            <dd>
              <xsl:value-of select="price"/>
            </dd>
            <dt>Tracks</dt>
            <xsl:for-each select="songs/song">
              <dd class="track">
                <xsl:value-of select="title"/>
                <span>
                  (<xsl:value-of select="duration"/>)
                </span>
              </dd>
            </xsl:for-each>
          </div>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
