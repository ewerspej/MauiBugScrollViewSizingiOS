# MauiBugScrollViewSizingiOS

Issue https://github.com/dotnet/maui/issues/15374 still persists even with this workaround: https://github.com/dotnet/maui/issues/14257#issuecomment-1646408225 applied.
When the content of a ScrollView is nested and growing and then shrinking again, the ScrollView remains too large and doesn't collapse to the shrunk size of its content, e.g. when there is more than a single nesting level inside the ScrollView.

This works:

```xml
<ScrollView>
    <VerticalStackLayout>
        <!-- expandable content goes here -->
    </VerticalStackLayout>
</ScrollView>
```

This doesn't:

```xml
<ScrollView>
    <Grid>
        <VerticalStackLayout>
            <!-- expandable content goes here -->
        </VerticalStackLayout>
    </Grid>
</ScrollView>
```

Issue https://github.com/dotnet/maui/issues/14257 is fixed with and without the workaround applied.

