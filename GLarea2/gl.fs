varying highp vec3 FragPos;
varying highp vec3 Normal;

uniform highp vec3 lightPos;
uniform highp vec3 viewPos;
uniform mediump vec3 lightColor;
uniform mediump vec3 objectColor;

void main(void)
{
	float ambientStrength = 0.1;
	vec3 ambient = ambientStrength * lightColor;

	vec3 norm = normalize(Normal);
	vec3 lightDir = normalize(lightPos - FragPos);
	float diff = max(dot(norm, lightDir), 0.0); 
	vec3 diffuse = diff * lightColor;

	float specularStrength = 0.5;
	vec3 viewDir = normalize(viewPos - FragPos);
	vec3 reflectDir = reflect(-lightDir, norm);
	float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
	vec3 specular = specularStrength * spec * lightColor;

	vec3 result = (0.01*ambient + diffuse + 0.01*specular) * objectColor;

	gl_FragColor = vec4(result, 1.0);
}