---
layout: default
title: Site editing
nav_order: 10000
has_children: false
---

# Site editing guidelines
{: .no_toc }


## Contents
{: .no_toc .text-delta }

1. TOC
{:toc}

---

## Site navigation
The main navigation of the site is on the left side of the page. It can be structured to accommodate a multi-level menu system (pages with children and grandchildren).
By default, all pages will appear as top level pages in the main nav unless a parent page is defined , see [`Parent` in front matter](#site-nav-frontmatter-parent).

### Limitations
- The main navigation supports only three hierarchy levels - design your page hierarchy carefully!


### Front matter {#site-nav-frontmatter-top}
Front matter is a piece of metadata in YAML format at the very top of the page source file. This metadata contains special information that controls the rendered appearance or behavior of the page.

```yaml
# Set the text that:
#  - appears in the left-hand site navigation
#  - is used a reference when specifying the 'parent' and 'grand_parent' settings for children / grandchildren pages
title: Configuration

# Set to 'true' if a page has child pages
has_children: true|false
```
#### 'parent' {#site-nav-frontmatter-parent}
{: .no_toc }
```yaml
# Set 'parent'
parent: the 'title' text of the direct hierarchical parent page
```
#### 'grand_parent' {#site-nav-frontmatter-grandparent}
{: .no_toc }
```yaml
# Set 'grand_parent'
grand_parent: the 'title' text of the grandparent (parent of parent) page
```



## In-page table of contents
The 'just the Docs' page theme can automatically generate a table of contents _for a given page_ based on headings and heading levels. To make this ToC appear, use the following Markdown code:

```markdown
# Heading 1 page title, excluded from ToC
{: .no_toc }

## Text above rendered ToC, excluded from ToC
{: .no_toc .text-delta }

1. TOC
{:toc}
```

Explanation:
- the `{: .no_toc }` code excludes the preceding heading from the ToC
- the `{:toc}` code is the point where the generated ToC is inserted
- the `{:toc}` code must be preceded by either:
    - `1. TOC`
- the `{:toc}` code can be used only once in one page


More information:

<https://just-the-docs.github.io/just-the-docs/docs/navigation-structure/#in-page-navigation-with-table-of-contents>
## Source code examples
Enclose source code examples in triple-backtick fences:
```` markdown
```
generic source code example
```

``` csharp
var cSharpString = "This is a C# example with color-coding";
```

``` xml
<?xml version="1.0" standalone="yes"?>
<root_node>
  <child>
    <MyID>PropID</MyID>
    <MyValue>0</MyValue>
  </child>
</root_node>
```
````


## Include common content into other files
Re-using common file content and re-using them in multiple target files is possible in two ways:

1.
 {% raw %} 
 {% include FileDirectlyInIncludes.md %}
 {% endraw %}

 2.
  {% raw %} 
  {% include_relative FileToIncludeRelativeToTargetFile.md %}
  {% endraw %}

### Including files from the site level `_includes` folder
On the site level, common files stored in the `_includes` folder can be included into other files using the `include` Liquid tag:
```
{% raw %}
{% include FileDirectlyInIncludes.md %}
{% endraw %}
```

The location of the `_includes` folder is pre-defined by Jekyll: must be in the root folder of the documentation source. In our case:<br>
`docs\_includes`

### Including files relative to target file
You can choose to include file fragments *relative* to the current file by using the `include_relative` tag:
```
{% raw %}
{% include_relative MySubDir/FileFromMySubDir.html %}
{% endraw %}
```

Note that you cannot use the `../` syntax to specify an include location that refers to a higher-level directory.